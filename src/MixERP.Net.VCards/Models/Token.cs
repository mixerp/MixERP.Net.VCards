using System.Collections.Generic;

namespace MixERP.Net.VCards.Models
{
    /// <summary>
    /// A token is representation of a valid vCard line in .NET.
    /// </summary>
    public class Token
    {
        //Binod: Feb 15, 2017
        //A token is a parsed form of vCard line. Take this as an example:         
        //ADR;TYPE=HOME,WORK;PREF=1:;;42 Plantation St.;Baytown;LA;30314;United States of America

        //The key in the above example is "ADR"
        public string Key { get; set; }

        //Additional key members are first splitted by ';', and then by '=' operator. 

        //DICTIONARY KEY  DICTIONARY VALUE
        //TYPE            HOME,WORK
        //PREF            1
        public Dictionary<string, string> AdditionalKeyMembers { get; set; }

        //The values for the above example:
        //0 -> NULL
        //1 -> NULL
        //2 -> 42 Plantation St.
        //3 -> Baytown
        //4 -> LA
        //5 -> 30314
        //6 -> United States of America
        public string[] Values { get; set; }
    }
}