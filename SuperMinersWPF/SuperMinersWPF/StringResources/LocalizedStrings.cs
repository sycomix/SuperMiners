﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMinersWPF.StringResources
{
    public sealed class LocalizedStrings
    {
        private static Strings _resource = new Strings();

        public Strings Strings
        {
            get
            {
                return _resource;
            }
        }
    }
}
