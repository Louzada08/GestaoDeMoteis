using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Enums;

namespace GestaoMotel.Application.Commands.Suites.Responses;

public class CreateSuiteResponse
{
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid CategoryId { get; set; }
        public StateSuiteEnum StateSuite { get; set; }
}
