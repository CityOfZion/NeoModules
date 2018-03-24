﻿using System;
using System.Collections.Generic;
using System.Text;
using NeoModules.Core;
using Newtonsoft.Json;
using Helper = NeoModules.KeyPairs.Helper;

namespace NeoModules.NEP6.Converters
{
    public class StringToInt160Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            UInt160 data = (UInt160)value;

            var stringData = Helper.ToAddress(data);

            writer.WriteValue(stringData);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = (string)reader.Value;
            return Helper.ToScriptHash(result);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
