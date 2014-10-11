using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevClone
{
	public class Employee
	{

		public const int MinimumWage = 100;

		public string FirstName;
		public string LastName;
		public byte Level{ get; set;} // from 1 to 10
		public int Wage{ get; set;}
		public int Experience;
		public byte Stress; // from 0 to 10
		public EmployeeInfo.Skill Speciality;
		public int UniqueId;

		public Dictionary<EmployeeInfo.Skill, byte> Skills; // skill levels go from 1 to 100

		public Employee(string firstName, string lastName, byte level, int wage, Dictionary<EmployeeInfo.Skill, byte> skills, EmployeeInfo.Skill speciality)
		{
			FirstName = firstName;
			LastName = lastName;
			Level = level;
			Wage = wage;
			Skills = skills;
			Speciality = speciality;
			UniqueId = firstName.GetHashCode() + lastName.GetHashCode() + level.GetHashCode() + wage.GetHashCode();
		}

		public string FullName
		{
			get{ return FirstName + " " + LastName; }
		}
		
		public byte ProgrammingSkill
		{
			get{ return Skills[EmployeeInfo.Skill.Programming]; }
			set{ Skills[EmployeeInfo.Skill.Programming] = value; }
		}

		public byte WritingSkill
		{
			get{ return Skills[EmployeeInfo.Skill.Writing]; }
			set{ Skills[EmployeeInfo.Skill.Writing] = value; }
		}

		public byte ArtSkill
		{
			get{ return Skills[EmployeeInfo.Skill.Art]; }
			set{ Skills[EmployeeInfo.Skill.Art] = value; }
		}

		public byte SoundEngineeringSkill
		{
			get { return Skills[EmployeeInfo.Skill.SoundEngineering]; }
			set { Skills[EmployeeInfo.Skill.SoundEngineering] = value; }
		}

		public byte DesigningSkill
		{
			get { return Skills[EmployeeInfo.Skill.Designing]; }
			set { Skills[EmployeeInfo.Skill.Designing] = value; }
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			builder.AppendLine("Nimi: " + FirstName + " " + LastName);
			builder.AppendLine("Taitotaso: " + Level);
			builder.AppendLine("Palkka: " + Wage + "€");
			builder.AppendLine("Speciality: " + Speciality);
			builder.AppendLine("UniqueId: " + UniqueId);
			return builder.ToString();
		}

		public static Employee GenerateNew(byte minLevel, byte maxLevel, EmployeeInfo.Skill speciality = EmployeeInfo.Skill.Nothing, bool noSkills = false, Random random = null)
		{
			var rand = random ?? new Random();
			var firstName = Utils.GetRandomString(EmployeeInfo.FirstNames, rand);
			var lastName = Utils.GetRandomString(EmployeeInfo.LastNames, rand);
			var level = (byte) rand.Next(minLevel, maxLevel + 1);
			var wage = rand.Next((int)(MinimumWage * level * 0.75f), (int)(MinimumWage * level * 1.5f));
			var skills = new Dictionary<EmployeeInfo.Skill, byte>();
			var spec = speciality;
			if (speciality == EmployeeInfo.Skill.Nothing && noSkills == false)
			{
				spec = Utils.GetRandomEnum<EmployeeInfo.Skill>(rand);
			}
			foreach (EmployeeInfo.Skill skill in Enum.GetValues(typeof(EmployeeInfo.Skill)))
			{
				byte skillLevel;
				if(skill == spec)
				{
					skillLevel = (byte)rand.Next(level * 5, level * 10 + 1);
					if (skillLevel > 90)
						wage=(int)(wage * 1.25f);
				}
				else
				{
					skillLevel = (byte)rand.Next(level, level * 5 + 1);
				}
				skills.Add(skill, skillLevel);
			}
			return new Employee(firstName, lastName, level, wage, skills, spec);
		}

		public static object EmployeeSpecialityImageGetter(object rowObject)
		{
			var emp = (Employee) rowObject;
			switch (emp.Speciality)
			{
				case EmployeeInfo.Skill.Art:
					return "artistIcon";
				case EmployeeInfo.Skill.Programming:
					return "programmerIcon";
				case EmployeeInfo.Skill.SoundEngineering:
					return "soundEngIcon";
				case EmployeeInfo.Skill.Designing:
					return "designerIcon";
				case EmployeeInfo.Skill.Writing:
					return "writerIcon";
				case EmployeeInfo.Skill.Nothing:
					return "skilllessIcon";
				default:
					return null;
			}
		}
	}

}
