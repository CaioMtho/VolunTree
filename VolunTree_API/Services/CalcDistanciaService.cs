namespace VolunTree_API.Services
{
    public class CalcDistanciaService
    {
        public double CalculateDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            var R = 6371;
            var lat1 = ToRadians(latitude1);
            var lat2 = ToRadians(latitude2);
            var lon1 = ToRadians(longitude1);
            var lon2 = ToRadians(longitude2);

            var dLat = lat2 - lat1;
            var dLon = lon2 - lon1;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        private double ToRadians(double degree)
        {
            return degree * (Math.PI / 180);
        }
    }
}
