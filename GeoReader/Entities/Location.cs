﻿using System.Runtime.InteropServices;

namespace GeoReader.Entities
{
    public class Location
    {
        public Location(string country, string region, string postal, string city, string organization, float latitude, float longitude)
        {
            Country = country;
            Region = region;
            Postal = postal;
            City = city;
            Organization = organization;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Country { get; } // название страны (случайная строка с префиксом "cou_")
        public string Region { get; } // название области (случайная строка с префиксом "reg_")
        public string Postal { get; } // почтовый индекс (случайная строка с префиксом "pos_")
        public string City { get; } // название города (случайная строка с префиксом "cit_")
        public string Organization { get; } // название организации (случайная строка с префиксом "org_")
        public float Latitude { get; } // широта
        public float Longitude { get; } // долгота
    } 
}