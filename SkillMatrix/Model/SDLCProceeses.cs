using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class SDLCProceeses
    {
        [Key]
        public int SDLCId { get; set; }
        public int EmployeeId { get; set; } 
        public int Coding_Standards { get; set; }
        public int Code_Optimization_Techniques { get; set; }
        public int ER_Diagram { get; set; }
        public int Swagger_UI { get; set; }
        public int Postman { get; set; }    
    }
}
