import { use, useEffect, useState } from 'react';
import { bowler } from './types/bowler';
import { team } from './types/team';

function BowlerList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);
  const [teams, setTeams] = useState<team[]>([]);

  useEffect(() => {
    const fetchBowlers = async () => {
      const response = await fetch('https://localhost:5000/api/Bowlers');
      const data = await response.json();
      setBowlers(data);
    };

    const fetchTeams = async () => {
      const response = await fetch('https://localhost:5000/api/Teams');
      const data = await response.json();
      setTeams(data);
    };

    fetchBowlers();
    fetchTeams();
  }, []);

  return (
    <>
      <h1>Bowlers</h1>
      <table>
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Adrress</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {(() => {
            // Create a lookup object for quick team name retrieval
            const teamLookup = {};
            teams.forEach((team) => {
              teamLookup[team.teamID] = team.teamName;
            });

            return bowlers.map((bowler) => (
              <tr key={bowler.bowlerID}>
                <td>
                  {bowler.bowlerFirstName} {bowler.bowlerMiddleInit}{' '}
                  {bowler.bowlerLastName}
                </td>
                <td>{teamLookup[bowler.teamID] || 'Unknown Team'}</td>
                <td>{bowler.bowlerAddress}</td>
                <td>{bowler.bowlerCity}</td>
                <td>{bowler.bowlerState}</td>
                <td>{bowler.bowlerZip}</td>
                <td>{bowler.bowlerPhoneNumber}</td>
              </tr>
            ));
          })()}
        </tbody>
      </table>
    </>
  );
}

export default BowlerList;
