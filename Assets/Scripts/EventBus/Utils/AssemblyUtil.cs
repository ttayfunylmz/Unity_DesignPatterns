using System;
using System.Collections.Generic;
using System.Reflection;

//Utility class for working with assemblies and types.
public static class AssemblyUtil 
{
    //Enumeration representing different types of assemblies.
    private enum AssemblyType 
    {
        AssemblyCSharp,
        AssemblyCSharpEditor,
        AssemblyCSharpEditorFirstPass,
        AssemblyCSharpFirstPass
    }

    //Method to map assembly names to AssemblyType enumeration values.
    private static AssemblyType? GetAssemblyType(string assemblyName) 
    {
        return assemblyName switch 
        {
            "Assembly-CSharp" => AssemblyType.AssemblyCSharp,
            "Assembly-CSharp-Editor" => AssemblyType.AssemblyCSharpEditor,
            "Assembly-CSharp-Editor-firstpass" => AssemblyType.AssemblyCSharpEditorFirstPass,
            "Assembly-CSharp-firstpass" => AssemblyType.AssemblyCSharpFirstPass,
            _ => null
        };
    }

    //Method to add types implementing a specified interface from an assembly to a collection.
    private static void AddTypesFromAssembly(Type[] assemblyTypes, Type interfaceType, ICollection<Type> results) 
    {
        if (assemblyTypes == null) return;
        for (int i = 0; i < assemblyTypes.Length; i++) 
        {
            Type type = assemblyTypes[i];
            if (type != interfaceType && interfaceType.IsAssignableFrom(type)) 
            {
                results.Add(type);
            }
        }
    }
    
    //Method to get types implementing a specified interface from all relevant assemblies.
    public static List<Type> GetTypes(Type interfaceType) 
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        
        Dictionary<AssemblyType, Type[]> assemblyTypes = new Dictionary<AssemblyType, Type[]>();
        List<Type> types = new List<Type>();
        for (int i = 0; i < assemblies.Length; i++) 
        {
            AssemblyType? assemblyType = GetAssemblyType(assemblies[i].GetName().Name);
            if (assemblyType != null) 
            {
                assemblyTypes.Add((AssemblyType) assemblyType, assemblies[i].GetTypes());
            }
        }
        
        assemblyTypes.TryGetValue(AssemblyType.AssemblyCSharp, out var assemblyCSharpTypes);
        AddTypesFromAssembly(assemblyCSharpTypes, interfaceType, types);

        assemblyTypes.TryGetValue(AssemblyType.AssemblyCSharpFirstPass, out var assemblyCSharpFirstPassTypes);
        AddTypesFromAssembly(assemblyCSharpFirstPassTypes, interfaceType, types);
        
        return types;
    }
}