using System.Collections.Generic;

namespace LibCerveceria
{
    public class CreadorDeCervezas
    {

        public List<Cerveza> CrearCervezas()
        {
            return new List<Cerveza>
            {
                new Cerveza("Rubia de origen nacional", 50f),
                new Cerveza("Negra de origen nacional", 58f),
                new Cerveza("Rubia de origen extranjero ", 65f),
            };
        }
    }
}