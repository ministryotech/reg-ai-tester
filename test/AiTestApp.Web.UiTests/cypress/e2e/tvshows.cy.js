describe('TV Shows UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('navigates to TV Shows page and picks a random show', () => {
    cy.get('nav .nav-link').contains('TV Shows').click();
    cy.url().should('include', '/TvShows');
    cy.get('h1').should('be.visible');
    cy.get('p').contains('Genre:').should('be.visible');

    cy.get('h1').then(($title1) => {
        const firstTitle = $title1.text();
        cy.get('.btn').contains('Pick Another Random TV Show').click();
        cy.get('h1').should(($title2) => {
            expect($title2.text()).to.not.equal(firstTitle);
        });
    });
  });
});
