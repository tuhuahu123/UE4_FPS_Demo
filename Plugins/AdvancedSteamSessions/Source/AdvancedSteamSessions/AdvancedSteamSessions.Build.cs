using UnrealBuildTool;  // 引入UnrealBuildTool命名空间，用于构建规则
using System.IO;        // 引入System.IO命名空间，用于文件操作

public class AdvancedSteamSessions : ModuleRules
{
    // 构造函数，初始化模块规则
    public AdvancedSteamSessions(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;  // 设置预编译头文件的使用方式

        // 添加公共定义，以便在编译时使用
        PublicDefinitions.Add("WITH_ADVANCED_STEAM_SESSIONS=1");

        // 指定模块的公共依赖项
        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core",                    // 核心模块
            "CoreUObject",             // 核心对象模块
            "Engine",                  // 引擎模块
            "InputCore",               // 输入核心模块
            "OnlineSubsystem",         // 在线子系统模块
            "OnlineSubsystemUtils",    // 在线子系统工具模块
            "Networking",              // 网络模块
            "Sockets",                 // 套接字模块
            "AdvancedSessions"         // 高级会话模块
        });

        // 指定模块的私有依赖项
        PrivateDependencyModuleNames.AddRange(new string[]
        {
            "OnlineSubsystem",         // 在线子系统模块
            "Sockets",                 // 套接字模块
            "Networking",              // 网络模块
            "OnlineSubsystemUtils"     // 在线子系统工具模块
        });

        // 如果目标平台是Win64、Linux或Mac，添加特定的依赖项和包含路径
        if ((Target.Platform == UnrealTargetPlatform.Win64) ||
            (Target.Platform == UnrealTargetPlatform.Linux) ||
            (Target.Platform == UnrealTargetPlatform.Mac))
        {
            PublicDependencyModuleNames.AddRange(new string[]
            {
                "Steamworks",           // Steamworks模块
                "OnlineSubsystemSteam"  // 在线子系统Steam模块
            });
            PublicIncludePaths.AddRange(new string[]
            {
                "../Plugins/Online/OnlineSubsystemSteam/Source/Private"  // Steam私有源代码路径
            });
        }
    }
}
