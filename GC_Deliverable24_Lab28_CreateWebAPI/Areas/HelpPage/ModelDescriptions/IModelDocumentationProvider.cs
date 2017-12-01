using System;
using System.Reflection;

namespace GC_Deliverable24_Lab28_CreateWebAPI.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}