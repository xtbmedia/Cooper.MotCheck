import React from 'react';
import ReactDOM from 'react-dom';

class RegistrationForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            email: ""
        };

        this.handleEmailChange = this.handleEmailChange.bind(this);
        this.handleSubmitForm = this.handleSubmitForm.bind(this);
    }

    render() {
        return this.state.reminderId == undefined
            ? this.dataEntryForm()
            : this.registrationConfirmed();
    }

    dataEntryForm() {
        return (<div>
            <p className="lead">Register with your email address and we'll send you a reminder to book your MOT 30 days before it's due.</p>
            <form onSubmit={this.handleSubmitForm} noValidate>
                <div className="form-group">
                    <label htmlFor="email">Email Address</label>
                    <div className="input-group input-group-lg">
                        <div className="input-group-prepend">
                            <span className="input-group-text">@</span>
                        </div>
                        <input className="form-control" aria-describedby="emailHelp" placeholder="address@example.com" type="email" required value={this.state.email} onChange={this.handleEmailChange}></input>
                    </div>
                    <small id="emailHelp" className="form-text text-muted">Enter the address to send the reminder to</small>
                    <small className="invalid-feedback">Email Address is required</small>
                </div>
                <div className="form-group">
                    <button className="btn btn-lg btn-primary btn-block">Register</button>
                </div>
            </form>
        </div>);
    }

    registrationConfirmed() {
        return (<div>
            <p className="lead">Your registration has been successful.</p>
            <a className="btn btn-lg btn-block btn-outline-secondary" href="/home/index">Check another vehicle</a>
        </div>);
    }

    async handleSubmitForm(event) {
        event.preventDefault();
        const form = event.target;

        if (form.checkValidity() === false) {
            form.classList.add('was-validated');
            return;
        }

        for (let i = 0; i < form.elements.length; i++) {
            form.elements[i].disabled = true;
        }

        const fetchOptions = {
            method: 'POST',
            body: JSON.stringify({
                registration: this.props.registration,
                manufacturer: this.props.manufacturer,
                model: this.props.model,
                motExpiryDate: this.props.motExpiryDate,
                email: this.state.email
            }),
            headers: {
                'Content-Type': 'application/json',
            }
        };
        const response = await fetch('/api/reminders', fetchOptions);
        const content = await response.json();
        this.setState({ reminderId: content.reminderId });

        for (let i = 0; i < form.elements.length; i++) {
            form.elements[i].disabled = false;
        }

    }

    handleEmailChange(event) {
        this.setState({
            email: event.target.value
        });
    }
}

const root = document.querySelector(".registration-form");
if (root !== null) {
    ReactDOM.render(<React.StrictMode>
        <RegistrationForm registration={root.dataset.registration} motExpiryDate={root.dataset.motExpiryDate} manufacturer={root.dataset.manufacturer} model={root.dataset.model} />
    </React.StrictMode>, root);
}