import React, { Component } from 'react';

export class Top3 extends Component {
  static displayName = Top3.name;

  constructor(props) {
    super(props);
    this.state = { top3: [], loading: true };
  }

  componentDidMount() {
    this.populateTop3Data();
  }

  static renderTop3Table(top3) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>No. of successful submissions</th>
            <th>Solved task names</th>
          </tr>
        </thead>
        <tbody>
          {top3.map(topUser =>
            <tr key={topUser.user}>
              <td>{topUser.user}</td>
              <td>{topUser.successfulSubmissions}</td>
              <td>{topUser.taskNames.join(', ')}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Top3.renderTop3Table(this.state.top3);

    return (
      <div>
        {contents}
      </div>
    );
  }

  async populateTop3Data() {
    const response = await fetch('user/ListUsers');
    const data = await response.json();
    this.setState({ top3: data.users, loading: false });
  }
}
