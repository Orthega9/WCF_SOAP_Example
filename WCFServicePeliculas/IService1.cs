using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicePeliculas.CLases;
using WCFServicePeliculas.EF;

namespace WCFServicePeliculas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]

        List<PeliculaMax> ListaPeliculas();

        [OperationContract]
        PeliculaMax Obtener(int id);

        [OperationContract]
        void Agregar(Pelicula p);

        [OperationContract]
        void Editar(Pelicula p);

        [OperationContract]
        void Eliminar(Pelicula p);

        [OperationContract]
        List<GeneroMax> ListaGenero();

        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "WCFServicePeliculas.ContractType".
   
}
