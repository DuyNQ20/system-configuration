
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace Configuration.Models
{
    public class FileUploadModel : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            
            if (operation.OperationId.ToString() == "ApiFileSystemsUploadFilesPost")
            {
                operation.Parameters.Clear();
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "file",
                    In = "formData",
                    Description = "Upload File",
                    Required = true,
                    Type = "file",
                    //Items = new PartialSchema{ Type = "file" }
                });
                operation.Consumes.Add("multipart/form-data");
            }
        }
    }
}
