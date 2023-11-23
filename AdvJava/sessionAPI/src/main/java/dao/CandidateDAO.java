package dao;
import pojos.Candidate;
import java.sql.Connection;
import java.sql.SQLException;
import java.util.List;

public interface CandidateDAO {
    
	// read
	// fetching a particular user data;
	Candidate getCandidate(String name, String party) throws SQLException;
	
	//Reading list of Candidates 
	List<Candidate> getCandidates() throws SQLException;
	
	
	//Update -> updating the vote count
	int UpdateVote(String name, String party )throws SQLException;
	
	
	
	void cleanUp() throws SQLException; 
	
	
	
}
