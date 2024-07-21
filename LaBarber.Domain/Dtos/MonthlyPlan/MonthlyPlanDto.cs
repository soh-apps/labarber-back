using LaBarber.Domain.Entities.MonthlyPlan;

namespace LaBarber.Domain.Dtos.MonthlyPlan
{
    public class MonthlyPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int CompanyId { get; set; }

        public MonthlyPlanDto()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Value = 0;
            CompanyId = 0;
        }

        public MonthlyPlanDto(int id, string name, string description, decimal value, int companyId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            CompanyId = companyId;
        }

        public MonthlyPlanDto(string name, string description, decimal value, int companyId)
        {
            Id = 0;
            Name = name;
            Description = description;
            Value = value;
            CompanyId = companyId;
        }

        public MonthlyPlanDto(MonthlyPlanEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Value = entity.Value;
            CompanyId = entity.CompanyId;
        }
    }
}
