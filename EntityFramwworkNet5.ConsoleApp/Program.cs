using EntityFramwworkNet5.Data;
using EntityFramwworkNet5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramwworkNet5.ConsoleApp
{
    class Program
    {
        private static readonly FootballLeagueDbContext context = new FootballLeagueDbContext();

        static async Task Main(string[] args)
        {
            var league = new League { Name = "Serie A" };


            await context.Leagues.AddAsync(league);


            await context.SaveChangesAsync();

            await AddTeamsWithLeague(league);
            await context.SaveChangesAsync();

            Console.WriteLine("Press Any Key To End...");
            Console.ReadKey();
            

        }



        static async Task AddTeamsWithLeague(League league)
        {
            var teams = new List<Team>
            {
                 new Team
                    {
                        Name = "Man United",
                        LeagueId = league.Id
                    },
                    new Team
                    {
                        Name = "Chelsea",
                        LeagueId = league.Id
                    },
                    new Team
                    {
                        Name = "Roma",
                        League = league
                    },
            };

            await context.AddRangeAsync(teams);
        } 
    }
}
