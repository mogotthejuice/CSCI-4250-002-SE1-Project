using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models {
    public enum LicenseTileType {
        FIXED_RESOURCES,        //player must pay using specific resources
        FIXED_NUM_RESOURCES,    //player chooses X number resources of Y different types
        VARIABLE_NUM_RESOURCES  //player chooses between 1-7 resources (any resources)
    }
}
