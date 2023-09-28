// See https://aka.ms/new-console-template for more information
using AutoMapper;

using AutoMapperConsole.TestClasses.Destinations;
using AutoMapperConsole.TestClasses.Sources;

using MortgageServices;

using System.ComponentModel;
using System.Reflection;

Console.WriteLine("Hello, World!");


#region Assembly scanning
//var rassemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(an => Assembly.Load(an));

//var assemblies = rassemblies
//    .Where(
//        assyName =>
//            (assyName.FullName.Contains("MyMidlandMortgage")
//                || assyName.FullName.Contains("Midland"))
//                && !assyName.FullName.Contains("Midland.Web.Mvc")
//                && !assyName.FullName.Contains("Midland.Security")
//                && !assyName.FullName.StartsWith("System")
//                && !assyName.FullName.StartsWith("Midland.LoanServ")
//                && !assyName.FullName.StartsWith("Midland.Aspose")
//    )
//    .Distinct()
//    .Concat(new[] { Assembly.GetExecutingAssembly() })
//    //.SelectMany(assyName => Assembly.Load(assyName).GetTypes().Where(t => t.BaseType == typeof(Profile)))
//    //.Where(assy => !assy.Location.Contains("GAC"))
//    .ToArray()
//;

#endregion Assembly scanning

Action<IMapperConfigurationExpression> mapperConfigExpression =
    cfg =>
    {
        cfg.CreateMap<OuterSource, OuterDest>()
            //.ForMember(d => d.Value, opt => opt.MapFrom(s => s.Value))
        ;
        
        cfg.CreateMap<InnerSource,  InnerDest>();
        //cfg.AddMaps(assemblies);
    };
//test mapper configuration expression builds valid mapper
var mapperConfig = new MapperConfiguration(mapperConfigExpression);
//mapperConfig.AssertConfigurationIsValid();


var mapper = mapperConfig.CreateMapper();

var source = new OuterSource() { Value = 10, Inner = new InnerSource() { OtherValue = 20 } };
var destination = new OuterDest() { Value = 30 };

try
{
    mapper.Map(source, destination, typeof(OuterSource), typeof(OuterDest));
}
catch(Exception ex)
{ 
    Console.WriteLine("failed");
};

OuterDest mapped;
try
{
    mapped = mapper.Map<OuterDest>(source);
}
catch (Exception ex)
{
    Console.WriteLine("failed");
};


var lastLine = "pause";






//builder.Register<IConfigurationProvider>(
//    ctx => new MapperConfiguration(mapperConfigExpression)
//).SingleInstance();

////Register Resolvers
//var autoMapperHelpers = new[] {
//                            typeof(IValueResolver<,,>),
//                            typeof(IMemberValueResolver<,,,>),
//                            typeof(ITypeConverter<,>),
//                            typeof(IValueConverter<,>),
//                            typeof(IMappingAction<,>)
//            };

//builder.RegisterTypes(
//    assemblies.SelectMany(a => a.GetTypes().Where(t => !t.IsInterface && !t.IsAbstract))
//    .Where(t => autoMapperHelpers.Any(amh => t.GetInterfaces().Select(i => i.GUID).Contains(amh.GUID)))
//    .ToArray()
//);

//builder.Register<IMapper>(
//    ctx => new Mapper(
//        ctx.Resolve<IConfigurationProvider>(),
//        ctx.Resolve<IComponentContext>().Resolve
//    )
//);