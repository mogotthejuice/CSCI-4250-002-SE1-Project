﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Locations {
    public class ResourceLocation : AbstractLocation {
        public Resources Resource { get; set; }
        public override void TakeAction(ref Player player) {
            throw new NotImplementedException();
        }
    }
}