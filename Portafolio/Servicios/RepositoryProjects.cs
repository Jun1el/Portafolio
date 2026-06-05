using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositoryProjects
    {
        List<Proyecto> ObtenerProyecto();
    }
    public class RepositoryProjects : IRepositoryProjects
    {
        public List<Proyecto> ObtenerProyecto()
        {
            return new List<Proyecto> {
                new Proyecto {
                    Titulo = "Sistemas de reclamos banco de la nacion - Internet - Intranet",
                    Descripcion = "Proyecto de mitigacion vulneravilidades CSP e implementacion de funcionalidades en sistema legacy en ASP.NET Webforms" ,
                    Link ="https://reclamos.bn.com.pe/SARE_inter/",
                    ImgURL="https://www.bn.com.pe/img/logobn-compartir.png"
                },
                new Proyecto {
                    Titulo = "Proyecto del clasificador de papas",
                    Descripcion = "Proyecto enfocado a clasificar papas defectuosas mediante segmentacion y entrenamiento de modelos de clasificacion usando un dataset publico " ,
                    Link ="https://github.com/Jun1el/Project-Grafica-Papa",
                    ImgURL="https://storage.googleapis.com/kaggle-datasets-images/2110080/3505874/a436a8e7b5bd3fcc953462e9b2cce68e/dataset-cover.png?t=2023-08-21-13-35-34"
                },
                new Proyecto {
                    Titulo = "Integración de métricas ágiles: Burn-Down y lead time con scripts personalizados",
                    Descripcion = "El Proyecto está enfocado en desarrollar scripts personalizados para calcular metricas agiles como burn-down y lead time" ,
                    Link ="https://github.com/JunalChowdhuryG/Grupo-2-Practica-Calificada-3",
                    ImgURL="https://t2informatik.de/en/wp-content/uploads/sites/2/2024/01/burn-down-chart-smartpedia.jpg"
                },
                new Proyecto {
                    Titulo = "Proyecto del clasificador de papas",
                    Descripcion = "Proyecto enfocado a clasificar papas defectuosas mediante segmentacion y entrenamiento de modelos de clasificacion usando un dataset publico " ,
                    Link ="https://github.com/Jun1el/Project-Grafica-Papa",
                    ImgURL="https://storage.googleapis.com/kaggle-datasets-images/2110080/3505874/a436a8e7b5bd3fcc953462e9b2cce68e/dataset-cover.png?t=2023-08-21-13-35-34"
                },
            };
        }
    }
}
