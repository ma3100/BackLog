using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog4dotnet.http
{
    public interface BacklogHttpResponse
    {
        int getStatusCode();

        Stream asInputStream();

        String asString();

        String getFileNameFromContentDisposition();
    }
}
