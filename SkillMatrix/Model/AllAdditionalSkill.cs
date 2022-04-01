using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class AllAdditionalSkill
    {
        [Key]
        public int AllAdditionalSkillId { get; set; }
        public int AdditionalSkillId { get; set; }
        public int EmpId { get; set; }        
        public int SingleApiCall { get; set; }
        public int ApolloExpress { get; set; }
        public int DataLoader { get; set; }
        public int ProressiveWebAppDev { get; set; }
        public int Wpf { get; set; }
        public int Sitecore { get; set; }
        public int Xamarin { get; set; }
        public int KenticoCms { get; set; }
        public int UmbracoCms { get; set; }
        public int Microservices { get; set; }

    }
}
