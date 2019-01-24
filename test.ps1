$CONFIG = $args[0]
$OUTPUT = $args[1]

$TargetArgs = $null

Switch ($CONFIG) {
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

& OpenCover.Console.exe -register:user -target:"vstest.console" -targetargs:"$TargetArgs" -output:"$OUTPUT"
& vstest.console $TargetArgs /Logger:Appveyor /Parallel /Enablecodecoverage /InIsolation /Blame
