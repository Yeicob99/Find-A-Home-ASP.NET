using Find_A_Home.Models;
using Microsoft.EntityFrameworkCore;

namespace Find_A_Home.Data.Seed
{
    public static class LocationSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedProvinces(modelBuilder);
            SeedZones(modelBuilder);
        }

        private static void SeedProvinces(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                new Province
                {
                    Id = 1,
                    Name = "Distrito Nacional"
                },
                new Province
                {
                    Id = 2,
                    Name = "Santo Domingo"
                },
                new Province
                {
                    Id = 3,
                    Name = "Santiago"
                },
                new Province
                {
                    Id = 4,
                    Name = "La Altagracia"
                }
            );
        }

        private static void SeedZones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zone>().HasData(

                // Distrito Nacional
                new Zone
                {
                    Id = 1,
                    Name = "Naco",
                    ProvinceId = 1
                },
                new Zone
                {
                    Id = 2,
                    Name = "Piantini",
                    ProvinceId = 1
                },
                new Zone
                {
                    Id = 3,
                    Name = "Evaristo Morales",
                    ProvinceId = 1
                },
                new Zone
                {
                    Id = 4,
                    Name = "Bella Vista",
                    ProvinceId = 1
                },
                new Zone
                {
                    Id = 5,
                    Name = "Los Prados",
                    ProvinceId = 1
                },
                new Zone
                {
                    Id = 6,
                    Name = "La Esperilla",
                    ProvinceId = 1
                },
                new Zone
                {
                    Id = 7,
                    Name = "Gazcue",
                    ProvinceId = 1
                },
                new Zone
                {
                    Id = 8,
                    Name = "Serrallés",
                    ProvinceId = 1
                },

                // Provincia Santo Domingo
                new Zone
                {
                    Id = 9,
                    Name = "Alma Rosa",
                    ProvinceId = 2
                },
                new Zone
                {
                    Id = 10,
                    Name = "Ensanche Ozama",
                    ProvinceId = 2
                },
                new Zone
                {
                    Id = 11,
                    Name = "Los Mina",
                    ProvinceId = 2
                },
                new Zone
                {
                    Id = 12,
                    Name = "Ciudad Juan Bosch",
                    ProvinceId = 2
                },
                new Zone
                {
                    Id = 13,
                    Name = "San Isidro",
                    ProvinceId = 2
                },
                new Zone
                {
                    Id = 14,
                    Name = "Los Alcarrizos",
                    ProvinceId = 2
                },
                new Zone
                {
                    Id = 15,
                    Name = "Las Caobas",
                    ProvinceId = 2
                },
                new Zone
                {
                    Id = 16,
                    Name = "Ciudad Modelo",
                    ProvinceId = 2
                },

                // Santiago
                new Zone
                {
                    Id = 17,
                    Name = "Cerros de Gurabo",
                    ProvinceId = 3
                },
                new Zone
                {
                    Id = 18,
                    Name = "Los Jardines Metropolitanos",
                    ProvinceId = 3
                },
                new Zone
                {
                    Id = 19,
                    Name = "Villa Olga",
                    ProvinceId = 3
                },
                new Zone
                {
                    Id = 20,
                    Name = "La Trinitaria",
                    ProvinceId = 3
                },
                new Zone
                {
                    Id = 21,
                    Name = "Gurabo",
                    ProvinceId = 3
                },
                new Zone
                {
                    Id = 22,
                    Name = "El Embrujo",
                    ProvinceId = 3
                },

                // La Altagracia
                new Zone
                {
                    Id = 23,
                    Name = "Punta Cana",
                    ProvinceId = 4
                },
                new Zone
                {
                    Id = 24,
                    Name = "Bávaro",
                    ProvinceId = 4
                },
                new Zone
                {
                    Id = 25,
                    Name = "Verón",
                    ProvinceId = 4
                },
                new Zone
                {
                    Id = 26,
                    Name = "Cap Cana",
                    ProvinceId = 4
                },
                new Zone
                {
                    Id = 27,
                    Name = "Uvero Alto",
                    ProvinceId = 4
                },
                new Zone
                {
                    Id = 28,
                    Name = "Macao",
                    ProvinceId = 4
                }
            );
        }
    }
}