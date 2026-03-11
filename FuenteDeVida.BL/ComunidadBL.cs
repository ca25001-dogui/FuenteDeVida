using SistemaContabilidad.DAL;
using SistemaContabilidad.EN;
using System.Collections.Generic;

namespace SistemaContabilidad.BL
{
    public class ComunidadBL
    {
        public int Guardar(Comunidad pComunidad)
        {
            return ComunidadDAL.Guardar(pComunidad);
        }

        public int Modificar(Comunidad pComunidad)
        {
            return ComunidadDAL.Modificar(pComunidad);
        }

        public int Eliminar(Comunidad pComunidad)
        {
            return ComunidadDAL.Eliminar(pComunidad);
        }

        public Comunidad ObtenerPorId(int pIdComunidad)
        {
            return ComunidadDAL.ObtenerPorId(pIdComunidad);
        }

        public List<Comunidad> Buscar(Comunidad pComunidad)
        {
            return ComunidadDAL.Buscar(pComunidad);
        }
    }
}

