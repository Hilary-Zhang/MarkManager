using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService”。
[ServiceContract]
public interface IService
{
	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

    [OperationContract]
    int Login(String username, String password, short type);

    [OperationContract]
    List<Model.Clazz> GetClazzs();

    [OperationContract]
    int UpdateClazz(Model.Clazz clazz);

    [OperationContract]
    int DeleteClazz(int id);

    [OperationContract]
    List<Model.Clazz> FindClazz(String name);
}

// 使用下面示例中说明的数据约定将复合类型添加到服务操作。
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}
