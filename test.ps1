$IMAGE = $args[0]
$CONFIGURATION = $args[1]
$OUTPUT = $args[2]

$Target = $null
$TargetArgs = $null

Switch ($IMAGE) {
    'Visual Studio 2019 Preview' {
        $Target = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
        Break
    }
    'Visual Studio 2017' {
        $Target = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
        Break
    }
    default {
        Write-Output "Invalid image: Image should be chosen from `"Visual Studio 2019 Preview`" and `"Visual Studio 2017`"."
        Exit
    }
}

Switch ($CONFIGURATION) {
    'Debug' {
        $TargetArgs = ".\ChatExercise.Test\bin\Debug\ChatExercise.Test.dll"
        Break
    }
    'Release' {
        $TargetArgs = ".\ChatExercise.Test\bin\Release\ChatExercise.Test.dll"
        Break
    }
    default {
        Write-Output "Invalid configuration: Configuration should be chosen from `"Debug`" and `"Release`"."
        Exit
    }
}

& OpenCover.Console.exe -register:user -target:"$Target" -targetargs:"$TargetArgs" -output:"$OUTPUT"