﻿using System;
using System.Runtime.InteropServices;

namespace GeoReader.Entities
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 60, CharSet = CharSet.Ansi)]
    public struct Header
    {
        public int version; // версия база данных

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string name; // название/префикс для базы данных

        public DateTime timestamp; // время создания базы данных

        public int records; // общее количество записей

        public uint offset_ranges; // смещение относительно начала файла до начала списка записей с геоинформацией

        public uint offset_cities
            ; // смещение относительно начала файла до начала индекса с сортировкой по названию городов

        public uint offset_locations; // смещение относительно начала файла до начала списка записей о местоположении
    }
}