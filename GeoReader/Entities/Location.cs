﻿using System.Runtime.InteropServices;

namespace GeoReader.Entities
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 96, CharSet = CharSet.Ansi)]
    public struct Location
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string country; // название страны (случайная строка с префиксом "cou_")

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string region; // название области (случайная строка с префиксом "reg_")

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string postal; // почтовый индекс (случайная строка с префиксом "pos_")

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string city; // название города (случайная строка с префиксом "cit_")

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string organization; // название организации (случайная строка с префиксом "org_")

        public float latitude; // широта

        public float longitude; // долгота
    }
}