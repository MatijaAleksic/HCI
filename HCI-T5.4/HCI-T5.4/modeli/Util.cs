using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace HCI_T5._4.modeli
{
    class Util
    {

        public ObservableCollection<T> read_file<T>(String name)
        {
            List<T> listEl = new List<T>();

            using (StreamReader r = new StreamReader(name))
            {
                string json = r.ReadToEnd();
                listEl = JsonConvert.DeserializeObject<List<T>>(json);
                r.Close();
            }
            return new ObservableCollection<T>(listEl);
        }

        public void write_to_file<T>(ObservableCollection<T> lista, String path)
        {
            using (StreamWriter w = new StreamWriter(path))
            {
                w.WriteLine("[\n");
                foreach (T elem in lista)
                {
                    string json = JsonConvert.SerializeObject(elem, Formatting.Indented);
                    w.WriteLine(json);
                    w.WriteLine(",\n");
                }
                w.WriteLine("]");
            }
        }
    }
    

}
