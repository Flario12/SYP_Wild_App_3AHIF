using System;
using System.Collections.Generic;
using System.Text;

namespace WildApp.Data
{
    public abstract class TestBasis
    {
        protected string jsonfile;

        public abstract string SerializeJSON(string jsonfile);

        public abstract void DeserializeJSON(string jsonfile);

        public string GetFilePath()
        {
            return jsonfile;
        }
    }
}
