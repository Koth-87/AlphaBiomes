﻿using System;
using RimWorld.Planet;
using RimWorld;
using UnityEngine;
using Verse;

namespace AlphaBiomes
{
    public class BiomeWorker_GelatinousSuperorganism : BiomeWorker
    {
        public override float GetScore(Tile tile, int tileID)
        {
            if (!AlphaBiomes_Settings.AB_SpawnGelatinousSuperorganism)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            if (tile.temperature < -10f)
            {
                return 0f;
            }
            if (tile.rainfall < 600f)
            {
                return 0f;
            }
           
            Vector3 tileCenter = Find.WorldGrid.GetTileCenter(tileID);
            if (Find.World.GetComponent<WorldComponentExtender>() == null)
            {
                     WorldComponent item = (WorldComponent)Activator.CreateInstance(typeof(WorldComponentExtender), new object[]
                    {
                        Find.World
                    });
                    Find.World.components.Add(item);
             }
            
            float tileWeirdness = Find.World.GetComponent<WorldComponentExtender>().noiseWeirdness.GetValue(tileCenter);
            //Log.Message(tileWeirdness.ToString());
            if (tileWeirdness > 0.75f)
            {
                return 100f;
            }
            else return 0f;
            //return 15f + (tile.temperature - 7f) + (tile.rainfall - 600f) / 180f + tile.swampiness * 10f;
        }
    }
}
