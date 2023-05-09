namespace PortalFerreteria.Shared.Services
{
    public class MainServices
    {
        private static MainServices instance;
        public static MainServices GetInstance()
        {
            if (instance == null)
            {
                return new MainServices();
            }

            return instance;
        }
        public MainServices()
        {
            instance = this;
        }

        #region Instacias de Clientes

        public ClientFactory ConectionService { get; set; } = new ClientFactory("https://localhost:44351/");
        public ClientFactory ConectionServiceUbicacion { get; set; } = new ClientFactory("http://190.54.179.197:7095/");

        //IP privada 192.168.15.7:7095
        //IP pública 190.54.179.197:7095
        #endregion
    }
}
