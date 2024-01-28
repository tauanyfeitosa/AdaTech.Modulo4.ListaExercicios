using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using AdaTech.Modulo4.ListaExercicios.Options;

namespace AdaTech.Modulo4.ListaExercicios.Services
{
    public class HotPotatoGameService
    {
        private readonly int _maxRandomNumber;
        private Random _random = new Random();

        public HotPotatoGameService(IOptions<HotPotatoGameOptions> options)
        {
            _maxRandomNumber = options.Value.MaxRandomNumber;
        }

        public string PlayHotPotato(int numberOfPlayers)
        {
            if (numberOfPlayers <= 1)
            {
                throw new ArgumentException("Deve haver pelo menos dois jogadores para jogar batata quente.");
            }

            StringBuilder result = new StringBuilder();
            Queue<int> playersQueue = new Queue<int>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                playersQueue.Enqueue(i);
            }

            while (playersQueue.Count > 1)
            {
                int passes = _random.Next(1, _maxRandomNumber + 1);

                for (int i = 0; i < passes; i++)
                {
                    int currentPlayer = playersQueue.Dequeue();
                    playersQueue.Enqueue(currentPlayer);
                }

                int explodedPlayer = playersQueue.Dequeue();
                result.AppendLine($"Jogador {explodedPlayer} explodiu, restam os jogadores: {string.Join(", ", playersQueue)}");

                passes = _random.Next(1, _maxRandomNumber + 1);
            }

            result.AppendLine($"Jogador {playersQueue.Dequeue()} venceu");
            return result.ToString();
        }
    }
}
