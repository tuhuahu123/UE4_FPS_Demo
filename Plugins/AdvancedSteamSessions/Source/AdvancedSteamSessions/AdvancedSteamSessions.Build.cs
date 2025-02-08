using UnrealBuildTool;  // ����UnrealBuildTool�����ռ䣬���ڹ�������
using System.IO;        // ����System.IO�����ռ䣬�����ļ�����

public class AdvancedSteamSessions : ModuleRules
{
    // ���캯������ʼ��ģ�����
    public AdvancedSteamSessions(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;  // ����Ԥ����ͷ�ļ���ʹ�÷�ʽ

        // ��ӹ������壬�Ա��ڱ���ʱʹ��
        PublicDefinitions.Add("WITH_ADVANCED_STEAM_SESSIONS=1");

        // ָ��ģ��Ĺ���������
        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core",                    // ����ģ��
            "CoreUObject",             // ���Ķ���ģ��
            "Engine",                  // ����ģ��
            "InputCore",               // �������ģ��
            "OnlineSubsystem",         // ������ϵͳģ��
            "OnlineSubsystemUtils",    // ������ϵͳ����ģ��
            "Networking",              // ����ģ��
            "Sockets",                 // �׽���ģ��
            "AdvancedSessions"         // �߼��Ựģ��
        });

        // ָ��ģ���˽��������
        PrivateDependencyModuleNames.AddRange(new string[]
        {
            "OnlineSubsystem",         // ������ϵͳģ��
            "Sockets",                 // �׽���ģ��
            "Networking",              // ����ģ��
            "OnlineSubsystemUtils"     // ������ϵͳ����ģ��
        });

        // ���Ŀ��ƽ̨��Win64��Linux��Mac������ض���������Ͱ���·��
        if ((Target.Platform == UnrealTargetPlatform.Win64) ||
            (Target.Platform == UnrealTargetPlatform.Linux) ||
            (Target.Platform == UnrealTargetPlatform.Mac))
        {
            PublicDependencyModuleNames.AddRange(new string[]
            {
                "Steamworks",           // Steamworksģ��
                "OnlineSubsystemSteam"  // ������ϵͳSteamģ��
            });
            PublicIncludePaths.AddRange(new string[]
            {
                "../Plugins/Online/OnlineSubsystemSteam/Source/Private"  // Steam˽��Դ����·��
            });
        }
    }
}
