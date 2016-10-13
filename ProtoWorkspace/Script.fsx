﻿System.IO.Directory.SetCurrentDirectory __SOURCE_DIRECTORY__
#r "bin/release/protoworkspace.dll"
#r "System.Reflection"
#r "../packages/System.Reflection.Metadata/lib/netstandard1.1/System.Reflection.Metadata.dll"
#r "../packages/System.Collections.Immutable/lib/netstandard1.0/System.Collections.Immutable.dll"
#r "../packages/Microsoft.Composition/lib/portable-net45+win8+wp8+wpa81/System.Composition.AttributedModel.dll"
#r "../packages/Microsoft.Composition/lib/portable-net45+win8+wp8+wpa81/System.Composition.Convention.dll"
#r "../packages/Microsoft.Composition/lib/portable-net45+win8+wp8+wpa81/System.Composition.Hosting.dll"
#r "../packages/Microsoft.Composition/lib/portable-net45+win8+wp8+wpa81/System.Composition.Runtime.dll"
#r "../packages/Microsoft.Composition/lib/portable-net45+win8+wp8+wpa81/System.Composition.TypedParts.dll"
#r "../packages/Microsoft.CodeAnalysis.Common/lib/net45/Microsoft.CodeAnalysis.dll"
#r "../packages/Microsoft.CodeAnalysis.Workspaces.Common/lib/net45/Microsoft.CodeAnalysis.Workspaces.Desktop.dll"
#r "../packages/Microsoft.CodeAnalysis.Workspaces.Common/lib/net45/Microsoft.CodeAnalysis.Workspaces.dll"

open ProtoWorkspace
open ProtoWorkspace.Workspace
open System.Composition
open System.Composition.Hosting
open Microsoft.CodeAnalysis
open Microsoft.CodeAnalysis.MSBuild
open Microsoft.CodeAnalysis.Host.Mef
open System.IO

let setup (ctx:CompositionContext) = 
    MefHostServices.Create ctx


let adhoc = new AdhocWorkspace()
let msbuildwork = MSBuildWorkspace.Create()

Path.GetFullPath("..\data\TestSln.sln");;

let load = (msbuildwork.OpenSolutionAsync "..\data\TestSln.sln").Result ;;
load.Id;;
printfn "%A" msbuildwork.CurrentSolution.FilePath;;

msbuildwork.CurrentSolution.Projects
|> Seq.iter (printfn "%A")
;;
//ProjectInfo.
msbuildwork.OpenProjectAsync("C:\Users\jared\Programming Projects\ProtoWorkspace\data\projects\Library1\Library1.fsproj")

type Foo = {
    Foo:int
    }

type Bar = {
    F:Foo
    }

let bar = {
    F = {
        Foo = 10
        }
    }
