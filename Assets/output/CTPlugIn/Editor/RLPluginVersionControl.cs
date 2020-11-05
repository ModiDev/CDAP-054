using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection;

[ InitializeOnLoad ]
internal class RLPluginVersionControl
{
	private static bool m_bProcessed = false;
	private static int  m_nFrameCount = 0;
	//Target path
	private static string m_kUnlightShadertargetPath = Application.dataPath + "/output/Resources/CTResources/Shader/Unlight Shader";
	private static string m_kLightShaderTargetPath   = Application.dataPath + "/output/Resources/CTResources/Shader/Light Shader";
	private static string m_kStandTargetDllPath  = "/output/CTPlugIn/Standard Assets/RL.dll";
	private static string m_kEditorTargetDllPath = "/output/CTPlugIn/Editor/RLGUI.dll";
	//Dll
	private static string m_kStdDllName    = "RL.dll";
	private static string m_kEditorDllName = "RLGUI.dll";
	
	//Unity 4
	private static string m_kUnity4StandDllPath  = "/output/CTPlugIn/Standard Assets/Unity4/";
	private static string m_kUnity4EditorDllPath = "/output/CTPlugIn/Editor/Unity4/";
	
	private static string m_kU4ShaderRootPath    = Application.dataPath + "/output/Resources/CTResources/Shader/Unity4";
	private static string m_kU4UnlightShaderPath = Application.dataPath + "/output/Resources/CTResources/Shader/Unity4/Unlight Shader";
	private static string m_kU4LightShaderPath   = Application.dataPath + "/output/Resources/CTResources/Shader/Unity4/Light Shader";
	
	//Unity 5
	private static string m_kUnity5StandDllPath  = "/output/CTPlugIn/Standard Assets/Unity5/";
	private static string m_kUnity5EditorDllPath = "/output/CTPlugIn/Editor/Unity5/";
	
	private static string m_kU5ShaderRootPath    = Application.dataPath + "/output/Resources/CTResources/Shader/Unity5";
	private static string m_kU5UnlightShaderPath = Application.dataPath + "/output/Resources/CTResources/Shader/Unity5/Unlight Shader";
	private static string m_kU5LightShaderPath   = Application.dataPath + "/output/Resources/CTResources/Shader/Unity5/Light Shader";
	
	//VersionControl
	private static string m_kSelfClassPath = "/output/CTPlugIn/Editor/RLPluginVersionControl.cs";
	
	//DemoProject Resource path
	private static string m_kDemoProjecrAsset1   = "/output/CTPlugIn/DemoProject";
	private static string m_kDemoProjectAsset2   = "/output/CTPlugIn/Free Demo Material";
	private static string m_kDemoProjectResource = "/output/Resources/DemoProjectResource";
	private static string m_kDemoProjectJS       = m_kDemoProjecrAsset1 + "/DemoProject.js";

	static RLPluginVersionControl()
	{
		EditorApplication.update += SwitchPluginVersion;
	}

	static void SwitchPluginVersion()
	{
		if( m_bProcessed || 
		    EditorApplication.isPlaying ||
		    EditorApplication.isCompiling || 
		    EditorApplication.isUpdating )
		{
			return;
		}
		Action kExitProcess = null;
        try
        {
			string kBigVer = Application.unityVersion.Substring( 0, 1 );
			int nBigVer;
			if( !int.TryParse( kBigVer, out nBigVer ) )
			{
				return;
			}
			if( ValidateImportStatus( nBigVer ) )
			{
				return;
			}
			//Init ExitProcess
			kExitProcess = ()=>
			{
				ClearConsole();
				m_bProcessed = true;
				EditorApplication.update -= SwitchPluginVersion;
				if( nBigVer >= 5 )
				{
					AssetDatabase.Refresh();
				}
				else
				{
					DelayReimport();
				}
			};

			if( nBigVer >= 5 )
			{
				AssetDatabase.MoveAsset( "Assets" + m_kUnity5StandDllPath  + m_kStdDllName,    "Assets" + m_kStandTargetDllPath );
				AssetDatabase.MoveAsset( "Assets" + m_kUnity5EditorDllPath + m_kEditorDllName, "Assets" + m_kEditorTargetDllPath );
				AssetDatabase.MoveAssetToTrash( "Assets" + m_kUnity4StandDllPath  + m_kStdDllName );
				AssetDatabase.MoveAssetToTrash( "Assets" + m_kUnity4EditorDllPath + m_kEditorDllName );
				//SwitchShader
				if( Directory.Exists( m_kUnlightShadertargetPath ) || 
				    Directory.Exists( m_kLightShaderTargetPath ) )
				{
					kExitProcess();
                    return;
                }
				FileUtil.MoveFileOrDirectory( m_kU5UnlightShaderPath, m_kUnlightShadertargetPath );
				FileUtil.MoveFileOrDirectory( m_kU5LightShaderPath,   m_kLightShaderTargetPath  );
            }
            else
            {
				AssetDatabase.MoveAsset( "Assets" + m_kUnity4StandDllPath  + m_kStdDllName,    "Assets" + m_kStandTargetDllPath );
				AssetDatabase.MoveAsset( "Assets" + m_kUnity4EditorDllPath + m_kEditorDllName, "Assets" + m_kEditorTargetDllPath );
				AssetDatabase.MoveAssetToTrash( "Assets" + m_kUnity5StandDllPath  + m_kStdDllName );
				AssetDatabase.MoveAssetToTrash( "Assets" + m_kUnity5EditorDllPath + m_kEditorDllName );
				//Delete Unity 5 DemoProject
				AssetDatabase.DeleteAsset( "Assets" + m_kDemoProjectJS );
				FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kDemoProjecrAsset1 );
				FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kDemoProjectAsset2 );
				FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kDemoProjectResource );
				//SwitchShader
				if( Directory.Exists( m_kUnlightShadertargetPath ) || 
				    Directory.Exists( m_kLightShaderTargetPath ) )
				{
					kExitProcess();
					return;
				}
				FileUtil.MoveFileOrDirectory( m_kU4UnlightShaderPath, m_kUnlightShadertargetPath );
				FileUtil.MoveFileOrDirectory( m_kU4LightShaderPath,   m_kLightShaderTargetPath );
			}
			AssetDatabase.Refresh();
			FileUtil.DeleteFileOrDirectory( m_kU4ShaderRootPath );
			FileUtil.DeleteFileOrDirectory( m_kU5ShaderRootPath );
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kUnity4StandDllPath   );
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kUnity4EditorDllPath  );
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kUnity5StandDllPath   );
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kUnity5EditorDllPath  );
			if( nBigVer >= 5 )
			{
				FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kSelfClassPath );
			}
		}
		catch( Exception e )
		{
			Debug.LogError( "RLPluginVersionControl : Failed to Switch Plugin. " + "( " + e.Message + " )" );
		}
		kExitProcess();
	}

	static bool ValidateImportStatus( int nCurrentVer )
	{
		if( nCurrentVer >= 5 )
		{
			if( Directory.Exists( Application.dataPath + m_kUnity4StandDllPath ) &&
			    Directory.Exists( Application.dataPath + m_kUnity5StandDllPath ) &&
			    Directory.Exists( m_kU4ShaderRootPath ) &&
			    Directory.Exists( m_kU5ShaderRootPath ) ) // Reimport Package
			{
				RemoveTargetPathData();
				m_bProcessed = false;
				return false;
			}
			else
			{
				if( File.Exists( Application.dataPath + m_kStandTargetDllPath ) ||
				    File.Exists( Application.dataPath + m_kEditorTargetDllPath ) )
				{
					m_bProcessed = true;
					EditorApplication.update -= SwitchPluginVersion;
					return true;
				}
				else
				{
					m_bProcessed = false;
					return false;
				}
			}
		}
		else //Unity Ver <= 4
		{
			if( !File.Exists( Application.dataPath + m_kUnity4StandDllPath + m_kStdDllName ) &&
			    File.Exists( Application.dataPath + m_kUnity5StandDllPath + m_kStdDllName ) ) //Reimport Package
			{
				RemoveImportData();
				m_bProcessed = true;
				EditorApplication.update -= SwitchPluginVersion;
				AssetDatabase.ImportAsset( "Assets/output/CTPlugIn/Standard Assets/RL.dll", ImportAssetOptions.ForceUpdate );
				return true;
			}
			else
			{
				if( File.Exists( Application.dataPath + m_kStandTargetDllPath ) ||
				    File.Exists( Application.dataPath + m_kEditorTargetDllPath ) )
				{
					m_bProcessed = true;
					EditorApplication.update -= SwitchPluginVersion;
					return true;
				}
				else
				{
					m_bProcessed = false;
					return false;
				}
			}
		}
	}

	static void RemoveTargetPathData()
	{
		string kStandTargetDllPath  = Application.dataPath + m_kStandTargetDllPath;
		string kEditorTargetDllPath = Application.dataPath + m_kEditorTargetDllPath;
		if( File.Exists( kStandTargetDllPath ) )
		{
			FileUtil.DeleteFileOrDirectory( kStandTargetDllPath );
		}
		if( File.Exists( kEditorTargetDllPath ) )
		{
			FileUtil.DeleteFileOrDirectory( kEditorTargetDllPath );
		}
		if( Directory.Exists( m_kUnlightShadertargetPath ) )
		{
			FileUtil.DeleteFileOrDirectory( m_kUnlightShadertargetPath );
		}
		if( Directory.Exists( m_kLightShaderTargetPath ) )
		{
			FileUtil.DeleteFileOrDirectory( m_kLightShaderTargetPath );
		}
		AssetDatabase.Refresh();
	}

	static void RemoveImportData()
	{
		//Demoproject
		if( Directory.Exists( Application.dataPath + m_kDemoProjecrAsset1 ) )
		{
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kDemoProjecrAsset1 );
		}
		if( Directory.Exists( Application.dataPath + m_kDemoProjectAsset2 ) )
		{
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kDemoProjectAsset2 );
		}
		if( Directory.Exists( Application.dataPath + m_kDemoProjectResource ) )
		{
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kDemoProjectResource );
		}
		//Shader
		if( Directory.Exists( m_kU4ShaderRootPath ) )
		{
			FileUtil.DeleteFileOrDirectory( m_kU4ShaderRootPath );
		}
		if( Directory.Exists( m_kU5ShaderRootPath ) )
		{
			FileUtil.DeleteFileOrDirectory( m_kU5ShaderRootPath );
		}
		//Dll
		if( Directory.Exists( Application.dataPath + m_kUnity4StandDllPath  ) )
		{
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kUnity4StandDllPath  );
		}
		if( Directory.Exists( Application.dataPath + m_kUnity4EditorDllPath  ) )
		{
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kUnity4EditorDllPath  );
		}
		if( Directory.Exists( Application.dataPath + m_kUnity5StandDllPath  ) )
		{
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kUnity5StandDllPath  );
		}
		if( Directory.Exists( Application.dataPath + m_kUnity5EditorDllPath  ) )
		{
			FileUtil.DeleteFileOrDirectory( Application.dataPath + m_kUnity5EditorDllPath  );
		}
		AssetDatabase.Refresh();
	}

	static void DelayReimport()
	{
		if( m_nFrameCount == 0 )
		{
			EditorApplication.update += DelayReimport;
		}
		else if( m_nFrameCount >= 60 )
		{
			m_nFrameCount = 0;
			EditorApplication.update -= DelayReimport;
			AssetDatabase.ImportAsset( "Assets/output/CTPlugIn/Editor/RLGUI.dll", ImportAssetOptions.ForceUpdate );
		}
		++m_nFrameCount;
	}

	static void ClearConsole()
	{
		var kAssembly = Assembly.GetAssembly( typeof( UnityEditor.ActiveEditorTracker ) );
		var type = kAssembly.GetType( "UnityEditorInternal.LogEntries" );
		var kMethod = type.GetMethod( "Clear" );
		kMethod.Invoke( new object(), null );
	}
}

