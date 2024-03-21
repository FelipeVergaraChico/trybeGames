namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    // 4. Crie a funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        // implementar
        var games = Games.FindAll(game => game.DeveloperStudio == gameStudio.Id);
        return games;
    }

    // 5. Crie a funcionalidade de buscar jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        // Implementar
        var getGamesPlayed = Games.FindAll(game => game.Players.Contains(player.Id));
        return getGamesPlayed;
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        // Implementar
        var getGamesOwned = Games.FindAll(game => playerEntry.GamesOwned.Contains(game.Id));
        return getGamesOwned;
    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        // Implementar
        var GetGamesWithStudio = (from game in Games
                                  join studio in GameStudios
                                  on game.DeveloperStudio equals studio.Id
                                  select new GameWithStudio
                                  {
                                    GameName = game.Name,
                                    StudioName = studio.Name,
                                    NumberOfPlayers = game.Players.Count
                                  }).ToList();
        return GetGamesWithStudio;
    }

    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        // Implementar
        var getGamesType = Games.Select(game => game.GameType).Distinct().ToList();
        return getGamesType;
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        // Implementar
        var getStudios = (from studio in GameStudios
                          select new StudioGamesPlayers
                          {
                            GameStudioName = studio.Name,
                            Games = (from game in Games
                                     where game.DeveloperStudio == studio.Id
                                     select new GamePlayer
                                     {
                                        GameName = game.Name,
                                        Players = (from player in Players
                                                   where game.Players.Contains(player.Id)
                                                   select player
                                        ).ToList()
                                     }
                                ).ToList()
                          }).ToList();

                          return getStudios;
    }

}
