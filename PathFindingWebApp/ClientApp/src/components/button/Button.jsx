import React from 'react';
import { Button as BootstrapButton } from 'reactstrap';

export const Button = ({ color='primary', disabled=false, children, ...restProps }) => (
    <BootstrapButton color={disabled ? 'secondary' : color} disabled={disabled} {...restProps}>
        {children}
    </BootstrapButton>
);
