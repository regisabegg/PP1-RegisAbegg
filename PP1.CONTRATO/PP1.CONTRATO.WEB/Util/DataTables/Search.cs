﻿using System;

namespace PP1.CONTRATO.WEB.Util.DataTables
{
    public class Search
    {
        public string Value
        {
            get;
            private set;
        }
        public bool IsRegexValue
        {
            get;
            private set;
        }
        public Search(string value, bool isRegexValue)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "The value of the search cannot be null. If there's no search performed, provide an empty string.");
            }
            this.Value = value;
            this.IsRegexValue = isRegexValue;
        }
    }
}
