using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Model;

// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、服务和配置文件中的类名“Service”。
public class Service : IService
{
    public Service()
    {
        DAL.DBHelper.connect("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True");
    }
    
	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

    public int Login(string username, string password,short type)
    {
        switch(type)
        {
            case 0://学生
                return DAL.Student.checkPassword(username, password);
            case 1://老师
                return DAL.Teacher.checkPassword(username, password);
            case 2://管理员
                return DAL.Admin.checkPassword(username, password);
            default:
                return 0;
        }
    }

    public List<Clazz> GetClazzs()
    {
        return DAL.Clazz.getClazzs();
    }

    public int UpdateClazz(Model.Clazz clazz)
    {
        if (clazz.id == 0)
        {
            return DAL.Clazz.insertClazz(clazz);
        }
        else
        {
            return DAL.Clazz.updateClazz(clazz);
        }
    }

    public int DeleteClazz(int id)
    {
        return DAL.Clazz.deleteClazz(id);
    }

    public List<Clazz> FindClazz(string name)
    {
        return DAL.Clazz.findClazz(name);
    }
}
