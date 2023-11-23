package dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import static utils.DBUtils.*;






import pojos.Candidate;
//id | name    | party    | votes
public class CandidateDAOImpl implements CandidateDAO {
    
	private Connection cn;
	private PreparedStatement pst1;
	private PreparedStatement pst2;
	private PreparedStatement pst3;
	
	public CandidateDAOImpl() throws SQLException {
		super();
		cn = getConnection();
		pst1= cn.prepareStatement("select * from candidates");
		pst2 = cn.prepareStatement("UPDATE candidates SET votes=? WHERE id=?");
		pst3 = cn.prepareStatement("SELECT * FROM candidates WHERE name=? AND party=?");
		System.out.println("Candidate DAO ready to proces CRUD requests!!");
	}

	@Override
	public List<Candidate> getCandidates() throws SQLException {
		// TODO Auto-generated method stub
		
		List<Candidate> candidateList = new ArrayList<>();
		try(ResultSet rst = pst1.executeQuery();)
		{
			
	        while(rst.next())
	        {
	       candidateList.add(new Candidate(rst.getInt(1), rst.getString(2), rst.getString(3), rst.getInt(4)));
	        }
		}
           
		return candidateList;
	}
	
	@Override
	public void cleanUp() throws SQLException
	{
		pst1.close();
	   cleanUp();
	}

	@Override
	public int UpdateVote(String name, String party) throws SQLException {
		Candidate person = getCandidate(name,party);
		if (person==null)
		{
			System.out.println("No candidate matching given candidate description!");
			return -1;
		}
		
		pst2.setInt(1, person.getVotes()+1);
		pst2.setInt(2, person.getid());
		pst2.executeUpdate();
		return person.getVotes()+1;
	}

	@Override
	public Candidate getCandidate(String name, String party) throws SQLException {
		// TODO Auto-generated method stub
		pst3.setString(1, name);
		pst3.setString(2, party);
		
		try(ResultSet rst = pst1.executeQuery())
		{
		 if (rst.next()==false)
		 {
			 return null;
		 }
		 return new Candidate(rst.getInt(1),rst.getString(2),rst.getString(3),rst.getInt(4));
		}
		
	}
	
	
	
	
}
