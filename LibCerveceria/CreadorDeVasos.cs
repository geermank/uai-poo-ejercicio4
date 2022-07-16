using System.Collections.Generic;

namespace LibCerveceria
{
    public class CreadorDeVasos
    {

        public List<Vaso> CrearVasos()
        {
            return new List<Vaso> {
                new Vaso("Chop", 0.75f),
                new Vaso("Vaso", 0.5f),
                new Vaso("Jarra", 3f)
            };
        }
    }
}