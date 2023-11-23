package pojos;

public class Team {
//	| team_id | name | abbrevation | owner  | max_age | batting_avg | wickets_taken

	private int teamId;
	private String name;
	private String abbrevation;
	private String owner;
	private int maxAge;
	private double battingAvg;
	private int wicketsTaken;
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getAbbrevation() {
		return abbrevation;
	}

	public void setAbbrevation(String abbrevation) {
		this.abbrevation = abbrevation;
	}

	public String getOwner() {
		return owner;
	}

	public void setOwner(String owner) {
		this.owner = owner;
	}

	public int getMaxAge() {
		return maxAge;
	}

	public void setMaxAge(int maxAge) {
		this.maxAge = maxAge;
	}

	public double getBattingAvg() {
		return battingAvg;
	}

	public void setBattingAvg(double battingAvg) {
		this.battingAvg = battingAvg;
	}

	public int getWicketsTaken() {
		return wicketsTaken;
	}

	public void setWicketsTaken(int wicketsTaken) {
		this.wicketsTaken = wicketsTaken;
	}
	
	public int getTeamId()
	{
		return this.teamId;
	}

	public Team(String name, String abbrevation, String owner, int maxAge, double battingAvg, int wicketsTaken) {
		super();
		this.name = name;
		this.abbrevation = abbrevation;
		this.owner = owner;
		this.maxAge = maxAge;
		this.battingAvg = battingAvg;
		this.wicketsTaken = wicketsTaken;
	}

	public Team(int teamId, String name, String abbrevation, String owner, int maxAge, double battingAvg,
			int wicketsTaken) {
		super();
		this.teamId = teamId;
		this.name = name;
		this.abbrevation = abbrevation;
		this.owner = owner;
		this.maxAge = maxAge;
		this.battingAvg = battingAvg;
		this.wicketsTaken = wicketsTaken;
	}
	
	
	
}
