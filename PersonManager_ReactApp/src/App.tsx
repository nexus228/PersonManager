import { useState } from 'react'


import { Icon } from '@mdi/react';
import { mdiPencil, mdiCardAccountDetails  } from '@mdi/js';


import './App.css'
import type { Person } from './types'


function App()
{
  
    const [persons, setPersons] = useState<Person[] > ([]); 
    const [selectedPerson, setSelectedPerson] = useState<Person | null>(null)

    const [searchText, setSearchText] = useState('');

    const filteredPersons = persons.filter(person => person.firstName.toLowerCase().includes(searchText.toLowerCase()) || person.name.toLowerCase().includes(searchText.toLowerCase()));

    const loadPersons = async () => {  

    try {     
        const response = await fetch("/api/person");
        
        const data = await response.json();

        setPersons(data);
       
    }
    catch (error) {
        console.error("FEHLER:", error);
        };
    };

    const clearList = () => { setPersons([]);};


  return (
      <>
              <h2>Personen-Manager</h2>

            
              
              <div className="styled_div">
                  <button className="styled_btn" onClick={loadPersons}>Personen laden</button>
                  <button className="styled_btn" disabled={persons.length === 0} onClick={clearList}>Liste leeren</button>  
              </div>

              <div className="styled_div">
                  <label>Suche eine Person anhand des Vornamens oder Nachnamens:</label>
                  <input className="styled_searchfield" type="text" placeholder="Search.." value={searchText} onChange={e => setSearchText(e.target.value)}/>
              </div>

           <div className="styled_div">
              <table>

              <thead>
                  <tr>
                      <th>Vorname</th>
                      <th>Name</th>
                      <th>Geburtsdatum</th>
                      <th>Aktionen</th>
                  </tr>
             </thead>
                 <tbody>
                    {filteredPersons.map(person => (
                        <tr key={person.id}>
           
                            <td>{person.firstName}</td>
                            <td>{person.name}</td>
                            <td>{new Date(person.dateOfBirth).toLocaleDateString('de-DE')}</td>
                            
                            <td>
                                <div>
                                <button className="styled_btn" onClick={() => setSelectedPerson(person)}><Icon path={mdiCardAccountDetails} size={0.7} /> Details</button>
                                <button className="styled_btn"><Icon path={mdiPencil} size={0.7} /> Bearbeiten</button>  
 
                            </div>
              
                            </td>
                        </tr>
                    ))}
                </tbody>
              </table>




          </div>


           {selectedPerson && (

                <div className="dialog_overlay">

                    <div className="details_dialog">

                        <h2>
                            {selectedPerson.firstName} {selectedPerson.name}
                        </h2>


                        <h3>Adressen</h3>

                        {selectedPerson.addresses?.length > 0 ? (

                            selectedPerson.addresses.map((address) => (

                                <div key={address.id}>

                                    <p>
                                        {address.street} {address.houseNumber}
                                        <br />
                                        {address.zipCode} {address.city}
                                    </p>

                                </div>

                            ))

                        ) : (

                            <p>
                                Keine Adressen vorhanden.
                            </p>

                        )}


                        <h3>Telefonnummern</h3>

                        {selectedPerson.phoneConnections?.length > 0 ? (

                            selectedPerson.phoneConnections.map((phone) => (

                                <p key={phone.id}>
                                    {phone.phoneNumber}
                                </p>

                            ))

                        ) : (

                            <p>
                                Keine Telefonnummern vorhanden.
                            </p>

                        )}


                        <div className="dialog_buttons">

                            <button
                                className="styled_btn"
                                onClick={() => setSelectedPerson(null)}>
                                Schließen
                            </button>

                        </div>

                    </div>

                </div>

            )}

        </>
    )
}

export default App
