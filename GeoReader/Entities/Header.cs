﻿using System;

namespace GeoReader.Entities
{
    public class Header
    {
        public Header(int version, string name, DateTime timestamp, int records, uint offsetRanges, uint offsetCities, uint offsetLocations)
        {
            Version = version;
            Name = name;
            Timestamp = timestamp;
            Records = records;
            OffsetRanges = offsetRanges;
            OffsetCities = offsetCities;
            OffsetLocations = offsetLocations;
        }

        public int Version { get; } // версия база данных

        public string Name { get; } // название/префикс для базы данных

        public DateTime Timestamp  { get; } // время создания базы данных

        public int Records { get; } // общее количество записей

        public uint OffsetRanges { get; } // смещение относительно начала файла до начала списка записей с геоинформацией

        public uint OffsetCities { get; } // смещение относительно начала файла до начала индекса с сортировкой по названию городов

        public uint OffsetLocations { get; } // смещение относительно начала файла до начала списка записей о местоположении
    }
}