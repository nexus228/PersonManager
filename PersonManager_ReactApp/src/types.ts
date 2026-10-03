export interface PhoneConnection { id: number; phoneNumber: string}
export interface Address { id: number; street: string; houseNumber: string; zipCode: string; city: string}
export interface Person { id: number; name: string; firstName: string; dateOfBirth: string; addresses:Address[]; phoneConnections:PhoneConnection[] }