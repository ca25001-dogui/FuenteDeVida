using FuenteDeVida.DAL;
using FuenteDeVida.EN;
using System.Collections.Generic;

namespace FuenteDeVida.BL
{
    public class RolBL
    {
        public int Guardar(RolBL pRol)
        {
            return RolDAL.Rol(pRol);
        }

        public int Modificar(RolBL pRol)
        {
            return RolDAL.Modificar(pRol);
        }

        public int Eliminar(RolBL pRol)
        {
            return RolDAL.Eliminar(pRol);
        }

        public Rol ObtenerPorId(short pIdRol)
        {
            return RolDAL.ObtenerPorId(pIdRol);
        }

        public List<Rol> Buscar(RolBL pRol)
        {
            return RolDAL.Buscar(pRol);
        }
    }

}
