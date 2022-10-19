using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VivasGRChat
{
    class Usuario
    {
        public string NickUser
        {
            set; get;
        }

        public string Contrasenha
        {
            set; get;
        }

        public string Estado
        {
            set;get;
        }

        public NetworkStream stream;

        public StreamWriter streamwriter;

        public StreamReader streamreader;
    }
}
