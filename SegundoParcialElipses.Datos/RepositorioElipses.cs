using SegundoParcialElipses.Entidades;

namespace SegundoParcialElipses.Datos
{

    public class RepositorioElipses
    {
        private List<Elipse> elipses;
        private string? nombreArchivo = "Elipses.txt";
        private string? rutaProyecto = Environment.CurrentDirectory;
        private string? rutaCompletaArchivo;

        public RepositorioElipses()
        {
            elipses = LeerDatos();
            
        }

        public void AgregarElipse(Elipse elipse)
        {
            elipses.Add(elipse);
        }

        public void EliminarElipse(Elipse elipse)
        {
            elipses.Remove(elipse);
        }

        public bool Existe(Elipse elipse)
        {
            return elipses.Any(e => e.SemiEjeMenor == elipse.SemiEjeMenor &&
                e.SemiEjeMayor == elipse.SemiEjeMayor);
        }

        public List<Elipse>? Filtrar(Borde bordeSeleccionado)
        {
            return elipses.Where(e => e.TipoBorde == bordeSeleccionado).ToList();
        }

        public int GetCantidad(Borde? bordeSeleccionado=null)
        {
            if(bordeSeleccionado == null)
                return elipses.Count;
            return elipses.Count(e=>e.TipoBorde==bordeSeleccionado);
        }

        public List<Elipse> ObtenerElipses()
        {
            return new List<Elipse>(elipses);
        }

        public List<Elipse>? OrdenarAsc()
        {
            return elipses.OrderBy(e => e.CalcularArea()).ToList();
        }

        public List<Elipse>? OrdenarDesc()
        {
            return elipses.OrderByDescending(e => e.CalcularArea()).ToList();
        }

        public bool Existe(int sM, int sm)
        {
            return elipses.Any(e => e.SemiEjeMayor == sM &&
            e.SemiEjeMenor == sm);
        }

        public void GuardarDatos()
        {
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            using (var escritor = new StreamWriter(rutaCompletaArchivo))
            {
                foreach (var elipse in elipses)
                {
                    string linea = ConstruirLinea(elipse);
                    escritor.WriteLine(linea);
                }
            }
        }

        private string ConstruirLinea(Elipse elipse)
        {
            return $"{elipse.SemiEjeMayor}|{elipse.SemiEjeMenor}|{elipse.TipoBorde.GetHashCode()}|{elipse.ColorElipse.GetHashCode()}";
        }
        private List<Elipse> LeerDatos()
        {
            var listaElipses=new List<Elipse>();
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            if (!File.Exists(rutaCompletaArchivo))
            {
                return listaElipses;
            }
            using (var lector = new StreamReader(rutaCompletaArchivo))
            {
                while (!lector.EndOfStream)
                {
                    string? linea=lector.ReadLine();
                    Elipse? elipse = ConstruirElipse(linea);
                    listaElipses.Add(elipse!);
                }
            }
            return listaElipses;

        }

        private Elipse? ConstruirElipse(string? linea)
        {
            var campos = linea!.Split('|');
            var sM = int.Parse(campos[0]);
            var sm = int.Parse(campos[1]);
            var tipoBorde = (Borde)int.Parse(campos[2]);
            var color=(ColorElipse)int.Parse(campos[3]);
            return new Elipse(sM,sm,tipoBorde,color);
        }
    }

}
