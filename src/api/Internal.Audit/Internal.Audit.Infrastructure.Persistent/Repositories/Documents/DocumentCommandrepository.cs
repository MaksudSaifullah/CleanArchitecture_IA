using Internal.Audit.Application.Contracts.Persistent.Documents;
using Internal.Audit.Domain.Entities.common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Documents;

public class DocumentCommandrepository : CommandRepositoryBase<Document>, IDocumentCommandRepository
{
    public DocumentCommandrepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }

    public async Task<(bool,string,string,string)> UploadFile(IFormFile file,string sourceName)
    {
        string path = "";
        string pathUpload = "UploadedFiles/" + sourceName;
        try
        {
            if (file.Length > 0)
            {
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, pathUpload));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = Path.GetRandomFileName();
                string ext = Path.GetExtension(file.FileName);
                pathUpload = pathUpload +"/" + fileName + ext;
                using (var fileStream = new FileStream(Path.Combine(path, fileName+ ext), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return (true,pathUpload, ext, file.FileName.Split('.')[0]);
            }
            else
            {
                return (false, "","","");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }
    }
}
